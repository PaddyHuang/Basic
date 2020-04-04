import requests
import os

root = '/Users/Polin/Downloads/'
url = 'https://gss0.baidu.com/-fo3dSag_xI4khGko9WTAnF6hhy/zhidao/pic/item/1c950a7b02087bf414ad6310f6d3572c10dfcf81.jpg'
#url = 'http://image.ngchina.com.cn/2020/0326/20200326102152775.jpg'
path = root + url.split('/')[-1]

try:
	if not os.path.exists(root):
		os.mkdir(root)
	if not os.path.exists(path):
		r = requests.get(url)
		with open(path, 'wb') as f:
			f.write(r.content)
			f.close()
			print('Downloaded')
	else:
		print('File existed')
except:
	print('Scrape failed')
