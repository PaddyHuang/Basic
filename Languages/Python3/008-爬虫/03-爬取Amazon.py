import requests

url = 'https://www.amazon.cn/dp/B07DDQTJP1'
header = {'user-agent' : 'Mozilla/6.0'}
try:
	r = requests.get(url, headers = header)
	r.raise_for_status()
	r.encoding = r.apparent_encoding
	print(r.text[1000:2000])
except:
	print('Scrape failed')

