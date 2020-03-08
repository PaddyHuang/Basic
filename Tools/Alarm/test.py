from playsound import playsound

def main():
	file = 'MySoul.mp3'
	file = file.encode('utf-8')
	playsound(file)

if __name__ == '__main__':
	main()
