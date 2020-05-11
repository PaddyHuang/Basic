# Note for Qt

> OS: macOS Mojave
>
> Environment: Xcode 11.3

## 1. Installation for Qt

### (1) Install Qt using homebrew

```shell
brew install qt								// for uninstall use: brew uninstall qt
```

and remember the position where qt is. We can use:

```shell
brew info qt
```

for me, that is /usr/local/Cellar/qt/5.14.2

### (2) Install Qt-creator

```shell
brew cask install qt-creator	// for uninstall use: brew cask uninstall qt-creator
```

qt is the base tool for qt-creator, but the latter cannot detect the former automatically. Thus, we need to configure qt-creator manually.

Step1: Preferences --> Kits --> Qt Versions --> Add: /usr/local/Cellar/qt/5.11.2/bin/qmake

Step2: Preferences --> Kits --> Kits, choose our desktop, choose compiler for clang(both c and c++) and choose Qt Version for the version we added previously.

Done.

## 2. Create 1st project

### (1) Click New --> Qt Widget Application --> name and choose somewhere to place it

These are ome detail configures:

- Build System: qmake

- Base class: Widget(without Generate form, which is a GUI method to manipulate UI. we will learn it later)

- Kits: Choose the one we added previously

- Version Control: Git

  Done. We could browse our project outline and then run it(A blank window).

  