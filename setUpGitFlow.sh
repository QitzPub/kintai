#!/bin/sh
sh resetAndLoad.sh
curl -L -O https://raw.github.com/nvie/gitflow/develop/contrib/gitflow-installer.sh
sudo bash gitflow-installer.sh
git flow init

