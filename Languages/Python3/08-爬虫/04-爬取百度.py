import requests

keyword = 'Python'
try:
	url = "http://www.baidu.com/s"
	kv = {'wd', keyword}
	header = {'user-agent' : 'Mozilla/6.0'}
	r = requests.get(url, params = kv, headers = header)
	print(r.request.url)
	r.raise_for_status()
	print(len(r.text))
except:
	print('Scrape failed')
