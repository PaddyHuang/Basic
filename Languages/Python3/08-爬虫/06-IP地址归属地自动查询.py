import requests

url = 'https://www.ip138.com/iplookup.asp?ip='
ip = '202.204.80.112'
kv = {'action' : '2'}
header = {'user-agent': 'Mozilla/6.0'}

try:
	r = requests.get(url + ip, headers = header, params = kv)
	r.raise_for_status()
	r.encoding = r.apparent_encoding
	print(r.text[:-500])
except:
	print('Scrape failed')
