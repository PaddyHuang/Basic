#!/bin/bash

echo "--> To be install components..."
# mv /etc/yum.repos.d/CentOS-Base.repo /etc/yum.repos.d/CentOS-Base.repo.backup \
#  && curl -o /etc/yum.repos.d/CentOS-Base.repo http://mirrors.aliyun.com/repo/Centos-8.repo \
#  && yum clean all \
#  && yum makecache

yum -y upgrade && yum -y update && yum -y groupinstall development
yum -y install yum-utils epel-release python36 python3-pip python3-devel cmake vim --skip-broken
# yum -y install vim* --skip-broken
yum -y clean packages && yum -y clean metadata

echo '--> Download theme molokai & vundle'
git clone https://github.com/tomasr/molokai.git /root/.vim/
git clone https://github.com/VundleVim/Vundle.vim.git /root/.vim/bundle/Vundle.vim
git clone https://github.com/ycm-core/YouCompleteMe.git /root/.vim/bundle/YouCompleteMe
echo '--> Install vim plugins'
# vim +PluginInstall +qall
vim -c PluginInstall -c q -c q

echo "--> Compile YouCompleteMe"
cd /root/.vim/bundle/YouCompleteMe/ && python3 ./install.py --all

echo '--> Finished'
