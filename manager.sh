#!/bin/sh

# root=/home/pi/Documents/Basic	# Raspian
root=/Users/Polin/Development/Basic
cd $root

Menu(){
	echo "######--Menu--######"
	echo "# 1. Browse Direstories."
	echo "# 2. Git add & commit & push."
	echo "# 3. New files."
	echo "# 0. Exit"
	echo "######--Menu--######"
}

Options(){
	read -p "Make an option: " option
}

# 1. Browse Direstories
BrowseDirectories(){
	echo "# 1. Browse Directories"
	echo "\t# (1) Data Structures"
	echo "\t# (2) Languages"
	read -p "Choose an directory: " dir
	case $dir in 
		1)	vim $root/Data_Structures;;
		2)	vim $root/Languages;;
		*);;
	esac
}

# 2. Git add & commit & push.
GitControl(){
	echo "# 2. Git add & commit & push"
	read -p "Commit Info: " info
	git add .; git commit -m "$info"; git push
}

# 3. New files
NewFile(){
	echo "# 3. New files."
	echo "1. C++"
	echo "2. Python"
	echo "3. Lua"
	read -p "Choose: " type
	case $type in
		1) 	read -p "Name: " name
			read -p "Description: " description
			cd $root/Languages/C\+\+/; touch $name.cpp
			echo "/*\nAuthor: Paddy Huang\nDate: $(date +"%Y-%m-%d %H:%M:%S")\nDescription: $description\n*/\n#include <iostream>\n" > $name.cpp
			cd $root; vim $root/Languages/C\+\+	;;
		2) 	read -p "Name: " name
			read -p "Description: " description
			cd $root/Languages/Python/; touch $name.py
			echo "#!/usr/bin/python3\n'''\nAuthor: Paddy Huang\nDate: $(date +"%Y-%m-%d %H:%M:%S")\nDescription: $description\n'''\n" > $name.py
			cd $root; vim $root/Languages/Python	;;
		3)	read -p "Name: " name
			read -p "Description: " description
			cd $root/Languages/Lua/; touch $name.lua
			echo "-- [Author: Paddy Huang]\n-- [Date: $(date +"%Y-%m-%d %H:%M:%S")]\n-- [Description: $description]\n" > $name.lua
			cd $root; vim $root/Languages/Lua	;;

		*)	;;
	esac
}

# 0. Exit
Exit(){
	echo "# 0. Exit"
	exit
}

clear
while :
do
	Menu
	Options
	case $option in
		1)	BrowseDirectories;;
		2)	GitControl;;
		3)	NewFile;;
		0)	Exit;;
		*)	clear; echo "No Options";;
	esac
done
