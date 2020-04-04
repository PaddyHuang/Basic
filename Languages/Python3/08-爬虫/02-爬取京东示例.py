import requests

url = 'https://item.jd.com/100008348542.html'
try:
	r = requests.get(url)
	r.raise_for_status()
	r.encoding = r.apparent_encoding
	print(r.text[:1000])
except:
	print('Scrape failed')
