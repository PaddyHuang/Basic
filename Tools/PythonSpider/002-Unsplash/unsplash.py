import requests

if __name__ == '__main__':
#	target = 'https://unsplash.com/'
	target = 'http://unsplash.com/napi/feeds/home'
	headers = {
	'Pragma' : 'no-cache',
    'Cache-Control' : 'no-cache',
    'Upgrade-Insecure-Requests' : '1',
    'User-Agent' : 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.170 Safari/537.36',
    'Accept' : 'text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8',
    'Accept-Language' : 'zh-CN,zh;q=0.9',
    'Connection' : 'close',
	}
	req = requests.get(url = target, headers = headers, verify = False)
	print(req.text)
