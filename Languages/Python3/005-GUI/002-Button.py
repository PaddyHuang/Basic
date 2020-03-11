import tkinter
from tkinter import messagebox

top = tkinter.Tk()
top.geometry('300x200')

def HelloCallBack():
	messagebox.showinfo('Hello Python', 'Hello World')

button = tkinter.Button(top, bg = 'black', fg = 'blue', text = 'Hello ', command = HelloCallBack)
button.pack()

#top.configure(bg = 'red')
top.mainloop()

