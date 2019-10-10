#!/bin/sh

root=/home/pi/Documents/Basic
cd $root

Menu(){
	echo "######--Menu--######"
	echo "# 1. Browse Direstories."
	echo "# 2. Git add & commit & push."
	echo "# 3. New file."
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

# 3. New files.
NewFiles(){
	echo "# 3. New files:"
	echo "1. C++"
	read -p "Choose: " types
	case $types in
		1)	read -p "Name: " name
			cd $root/Languages/C\+\+/; touch $name.cpp
			createdDay < date
			echo createdDay
			echo "/*------ Description ------\nAuthor: Paddy Huang\n*/" > $name.cpp	;;
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
		3)	NewFiles;;
		0)	Exit;;
		*)	clear; echo "No Options";;
	esac
done
