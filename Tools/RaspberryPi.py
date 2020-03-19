#!/usr/local/bin/python3
from os import system

def Menu():
	print("#######--Menu--#######")
	print("# 1. RaspberryPi Info.")
	print("# 2. RaspberryPi(Local).")
	print("# 3. RaspberryPi(Global).")
	print("# 0. Exit.")
	print("#######--Menu--#######")
	while True:
		options = input("Choose[0~3]: ")
		if options == '0': exit(0)
		elif options == '1': 
			info = '''	
				ID : pi
				Password: abc56pp2ab
				Local IP: 192.168.1.21:22
				Global IP: s21.natfrp.org -p 63576"
				'''
			print(info)
		elif options == '2':
			print('Local Raspberry Pi launching...')
			system('ssh pi@192.168.1.21')
		elif options == '3':
			print('Global Raspberry Pi launching...')
			system('ssh pi@s21.natfrp.org -p 63576')
		else:
			print("No options")
			
	return

def main():
	Menu()

if __name__ == '__main__':
	main()
