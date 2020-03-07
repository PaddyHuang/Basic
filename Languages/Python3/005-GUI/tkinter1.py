import tkinter

root = tkinter.Tk()	# 生成root主窗体
label = tkinter.Label(root, text = 'Hello GUI') # 生成标签
label.pack()	# 将标签添加到root主窗口
button1 = tkinter.Button(root, text = 'Button1')
button1.pack(side = tkinter.LEFT)
button2 = tkinter.Button(root, text = 'Button2')
button2.pack(side = tkinter.RIGHT)

root.mainloop()

