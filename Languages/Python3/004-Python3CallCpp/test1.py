import ctypes

def main():
	lib = ctypes.cdll.LoadLibrary('./test1.so')
	#lib = ll('./test1.so')
	lib.cfoo2(3, 4)

if __name__ == '__main__':
	main()
