#!/bin/bash

# Install brew
/bin/zsh -c "$(curl -fsSL https://gitee.com/cunkai/HomebrewCN/raw/master/Homebrew.sh)"

brew update
brew upgrade

brew cask install iina handshaker google-chrome wechat qq wpsoffice appcleaner docker ezip
