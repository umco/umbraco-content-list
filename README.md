# Content List

[![Build status](https://img.shields.io/appveyor/ci/UMCO/umbraco-content-list.svg)](https://ci.appveyor.com/project/UMCO/umbraco-content-list)
[![NuGet release](https://img.shields.io/nuget/v/Our.Umbraco.ContentList.svg)](https://www.nuget.org/packages/Our.Umbraco.ContentList)

An Umbraco property editor for creating a list of content blocks.

## Getting Started

### Installation

> *Note:* Content List has been developed against **Umbraco v7.7.0** and will support that version and above.

Content List can be installed from either NuGet package repositories, or build manually from the source-code:

#### NuGet package repository

To [install from NuGet](https://www.nuget.org/packages/Our.Umbraco.ContentList), you can run the following command from within Visual Studio:

	PM> Install-Package Our.Umbraco.ContentList

We also have a [MyGet package repository](https://www.myget.org/gallery/umbraco-packages) - for bleeding-edge / development releases.

#### Manual build

If you prefer, you can compile Content List yourself, you'll need:

* Visual Studio 2017 (or above)

To clone it locally click the "Clone in Windows" button above or run the following git commands.

	git clone https://github.com/umco/umbraco-content-list.git umbraco-content-list
	cd umbraco-content-list
	.\build.cmd

---

## Known Issues

Please be aware that not all property-editors will work within Content List. The following Umbraco core property-editors are known to have compatibility issues:

* Image Cropper
* Tags
* Upload

---

## Contributing to this project

Anyone and everyone is welcome to contribute. Please take a moment to review the [guidelines for contributing](CONTRIBUTING.md).

* [Bug reports](CONTRIBUTING.md#bugs)
* [Feature requests](CONTRIBUTING.md#features)
* [Pull requests](CONTRIBUTING.md#pull-requests)

---

## Contact

Have a question?

* [Raise an issue](https://github.com/umco/umbraco-content-list/issues) on GitHub

## Dev Team

* [Lee Kelleher](https://github.com/leekelleher)
* [Matt Brailsford](https://github.com/mattbrailsford)

## License

Copyright &copy; 2018 UMCO, Our Umbraco and [other contributors](https://github.com/umco/umbraco-content-list/graphs/contributors)

Licensed under the [MIT License](LICENSE.md)
