#!/usr/local/bin/python3
# Description: 将你的 QQ 头像（或者微博头像）右上角加上红色的数字，类似于微信未读信息数量那种提示效果。
# Author: Paddy Huang
# Date: 2020-03-20 12:15

from PIL import Image, ImageDraw, ImageFont

def add_num(img):
	draw = ImageDraw.Draw(img)
	myfont = ImageFont.truetype('/Library/Fonts/Arimo Bold for Powerline.ttf', size = 40)
	fillcolor = '#ff0000'
	width, height = img.size
	draw.text((width - 40, 0), '99', font = myfont, fill = fillcolor)
	img.save('result.jpg', 'jpeg')
	
	return 0;

if __name__ == '__main__':
	image = Image.open('1.jpg')
	add_num(image)

