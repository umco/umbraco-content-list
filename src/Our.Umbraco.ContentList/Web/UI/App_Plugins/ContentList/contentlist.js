angular.module("umbraco").controller("Our.Umbraco.ContentList.Controllers.PropertyEditorController", [

    "$scope",
    "innerContentService",

    function ($scope, innerContentService) {

        $scope.model.value = $scope.model.value || [];

        var vm = this;

        vm.allowAdd = (!$scope.model.config.maxItems || $scope.model.config.maxItems === "0" || $scope.model.value.length < $scope.model.config.maxItems);
        vm.allowEdit = true;
        vm.allowRemove = true;
        vm.published = true;
        vm.sortable = $scope.model.config.maxItems !== "1";

        vm.sortableOptions = {
            axis: "y",
            containment: "parent",
            cursor: "move",
            disabled: !vm.sortable,
            opacity: 0.7,
            scroll: true,
            tolerance: "pointer",
            stop: function (e, ui) {
                _.each($scope.model.value, function (itm, idx) {
                    innerContentService.populateName(itm, idx, $scope.model.config.contentTypes);
                });
                setDirty();
            }
        };

        vm.overlayConfig = {
            propertyAlias: $scope.model.alias,
            contentTypes: $scope.model.config.contentTypes,
            show: false,
            data: {
                idx: 0,
                model: null
            },
            callback: function (data) {
                innerContentService.populateName(data.model, data.idx, $scope.model.config.contentTypes);

                if (!($scope.model.value instanceof Array)) {
                    $scope.model.value = [];
                }

                if (data.action === "add") {
                    $scope.model.value.push(data.model);

                    if ($scope.model.config.maxItems !== "0" && $scope.model.value.length >= $scope.model.config.maxItems) {
                        vm.allowAdd = false;
                    }

                } else if (data.action === "edit") {
                    $scope.model.value[data.idx] = data.model;
                }
            }
        };

        vm.add = add;
        vm.edit = edit;
        vm.remove = remove;

        function add($event) {
            vm.overlayConfig.event = $event;
            vm.overlayConfig.data = { model: null, idx: $scope.model.value.length, action: "add" };
            vm.overlayConfig.show = true;
        };

        function edit($event, $index, item) {
            vm.overlayConfig.event = $event;
            vm.overlayConfig.data = { model: item, idx: $index, action: "edit" };
            vm.overlayConfig.show = true;
        };

        function remove($index) {
            $scope.model.value.splice($index, 1);

            if ($scope.model.config.maxItems === "0" || $scope.model.value.length < $scope.model.config.maxItems) {
                vm.allowAdd = true;
            }

            setDirty();
        };

        function setDirty() {
            if ($scope.propertyForm) {
                $scope.propertyForm.$setDirty();
            }
        };

        function initialize() {
            if ($scope.model.value.length > 0) {

                // Sync icons, as as it may have changed on the doctype
                var guids = _.uniq($scope.model.value.map(function (itm) {
                    return itm.icContentTypeGuid;
                }));

                innerContentService.getContentTypeIconsByGuid(guids).then(function (data) {
                    _.each($scope.model.value, function (itm) {
                        if (data.hasOwnProperty(itm.icContentTypeGuid)) {
                            itm.icon = data[itm.icContentTypeGuid];
                        }
                    });
                });
            }
        }

        initialize();
    }

]);
