#!/bin/bash
set -eu
add-apt-repository ppa:ermshiperete/monodevelop
apt-get update
apt-get install monodevelop-current
apt-get install monodoc-browser
#how to start
ln -s /opt/monodevelop/bin/monodevelop-launcher.sh start-mono
apt-get install mono-xbuild
