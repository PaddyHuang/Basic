#!/usr/local/bin/python3
from tkinter import *
#from pygame import mixer
#import ctypes
import time

def Confirm(a, b, c):
	#mixer.init()
	#mixer.music.load('MySoul.mp3')

	# clock = ctypes.cdll.LoadLibrary('./Alarm.so')
	# print(secondEntry.get())
	stopHour = int(a.get())
	stopMin = int(b.get())
	stopSec = int(c.get())
	target = stopHour * 10000 + stopMin * 100 + stopSec
	print(target)
	# clock.SetClock(startHour, startMin, startSec, stopHour, stopMin, stopSec)
	while True: 
		now = time.strftime('%H:%M:%S', time.localtime())
		now = now.split(':')
		hour, minute, second = now[0], now[1], now[2]
		now = int(hour) * 10000 + int(minute) * 100 + int(second)
		print(now)
		time.sleep(0.9)

		if now >= target:
			print('\a')
			#mixer.music.play()
			#time.sleep(10)
			#mixer.music.stop()
			#print('Times up')
			#exit(0)
	

def main():
	app = Tk()
	
	stopFrame= Frame(app)
	stopLabel = Label(stopFrame, bg = 'black', fg = 'white', text = 'Stop Time ')
	hour = Label(stopFrame, bg = 'black', fg = 'white', text = 'Hour: ')
	hourEntry = Entry(stopFrame, bd = 5, bg = 'black', fg = 'white')
	minute = Label(stopFrame, bg = 'black', fg = 'white', text = 'Minute: ')
	minuteEntry = Entry(stopFrame, bd = 5, bg = 'black', fg = 'white')
	second = Label(stopFrame, bg = 'black', fg = 'white', text = 'Second: ')
	secondEntry = Entry(stopFrame, bd = 5, bg = 'black', fg = 'white')
	button = Button(app, bg = 'black', fg = 'blue', text = 'Confirm', command = lambda : Confirm(hourEntry, minuteEntry, secondEntry))

	app.title('Tiny Alarm')
	#app.geometry('400x300')

	# Stop Frame
	stopFrame.pack()
	stopLabel.pack(side = LEFT)

	hour.pack(side = LEFT)
	hourEntry.pack(side = LEFT)

	minute.pack(side = LEFT)
	minuteEntry.pack(side = LEFT)

	second.pack(side = LEFT)
	secondEntry.pack(side = LEFT)

	button.pack()

	app.configure(bg = 'black')
	app.mainloop()

	
if __name__ == '__main__':
	main()
