#import tkinter
from tkinter import *
import ctypes

class Alarm:
	clock = ctypes.cdll.LoadLibrary('./Alarm.so')
	startHour = startMin = startSec =  0
	stopHour = stopMin = stopSec =  0
	app = Tk()
	
	startFrame = Frame(app)
	startLabel = Label(startFrame, bg = 'black', fg = 'white', text = 'Start Time ')
	hour1 = Label(startFrame, bg = 'black', fg = 'white', text = 'Hour: ')
	hourEntry1 = Entry(startFrame, bd = 5)
	minute1 = Label(startFrame, bg = 'black', fg = 'white', text = 'Minute: ')
	minuteEntry1 = Entry(startFrame, bd = 5)
	second1 = Label(startFrame, bg = 'black', fg = 'white', text = 'Second: ')
	secondEntry1 = Entry(startFrame, bd = 5)
	
	stopFrame= Frame(app)
	stopLabel = Label(stopFrame, bg = 'black', fg = 'white', text = 'Stop Time ')
	hour2 = Label(stopFrame, bg = 'black', fg = 'white', text = 'Hour: ')
	hourEntry2 = Entry(stopFrame, bd = 5)
	minute2 = Label(stopFrame, bg = 'black', fg = 'white', text = 'Minute: ')
	minuteEntry2 = Entry(stopFrame, bd = 5)
	second2 = Label(stopFrame, bg = 'black', fg = 'white', text = 'Second: ')
	secondEntry2 = Entry(stopFrame, bd = 5)

	def __init__(self):
		self.app.title('Tiny Alarm')
		#app.geometry('400x300')

		# Start Frame
		self.startFrame.pack()
		self.startLabel.pack(side = LEFT)

		self.hour1.pack(side = LEFT)
		self.hourEntry1.pack(side = LEFT)

		self.minute1.pack(side = LEFT)
		self.minuteEntry1 .pack(side = LEFT)

		self.second1.pack(side = LEFT)
		self.secondEntry1.pack(side = LEFT)

		# Stop Frame
		self.stopFrame.pack()
		self.stopLabel.pack(side = LEFT)

		self.hour2.pack(side = LEFT)
		self.hourEntry2.pack(side = LEFT)

		self.minute2.pack(side = LEFT)
		self.minuteEntry2.pack(side = LEFT)

		self.second2.pack(side = LEFT)
		self.secondEntry2.pack(side = LEFT)

		self.button.pack()

		# app.configure(bg = 'black')
		self.app.mainloop()

	def Confirm(self):
		# print(secondEntry1.get())
		self.startHour = int(self.hourEntry1.get())
		self.startMin = int(self.minuteEntry1.get())
		self.startSec = int(self.secondEntry1.get())
		self.stopHour = int(self.hourEntry2.get())
		self.stopMin = int(self.minuteEntry2.get())
		self.stopSec = int(self.secondEntry2.get())
		self.clock.SetClock(self.startHour, self.startMin, self.startSec, self.stopHour, self.stopMin, self.stopSec)
	
	button = Button(app, bg = 'black', fg = 'white', text = 'Confirm', command = Confirm)


def main():
	alarm = Alarm()

	
if __name__ == '__main__':
	main()
