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
                                Global IP: cn-cd-dx.sakurafrp.com -p 37700
				'''
			print(info)
		elif options == '2':
			print('Local Raspberry Pi launching...')
			system('ssh pi@192.168.1.107')
		elif options == '3':
			print('Global Raspberry Pi launching...')
			system('ssh pi@cn-cd-dx.sakurafrp.com -p 37700')
		else:
			print("No options")
	return

def main():
	Menu()

if __name__ == '__main__':
	main()
