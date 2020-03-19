#!/usr/local/bin/python3
import os

root = '/Users/Polin/Documents/blog'
os.chdir(root)
os.system('open -a "/Applications/Utilities/Terminal.app" ' + root)
os.system('code ' + root)

