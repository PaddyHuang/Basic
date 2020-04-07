import requests, re
from bs4 import BeautifulSoup

def getGuideHTML():
    try:
        url = 'http://pornbbs2048.com/'
        cookies = {'__cfduid': 'd25387a41d6400a8633c45d8d3a58787e1585985583',}
        headers = {
            #'Cache-Control': 'max-age=0',
            'DNT': '1',
            #'Upgrade-Insecure-Requests': '1',
            'User-Agent': 'Mozilla/5.0 (Macintosh; Intel Mac OS X 10_14_6) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.149 Safari/537.36',
            'Accept': 'text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9',
            'Accept-Language': 'zh-CN,zh;q=0.9,en;q=0.8',
            #'If-Modified-Since': 'Thu, 26 Mar 2020 09:36:08 GMT',
        }

        response = requests.get(url, headers=headers, cookies=cookies, verify=False)
        response.raise_for_status()
        response.encoding = response.apparent_encoding
        soup = BeautifulSoup(response.text, 'html.parser')
        a = soup.find_all('a')[:4]
        # print(a)
        address = []
        for item in a:
            addr = re.search(r'".*?"', str(item))
            # print(addr.group(0))
            address.append(addr.group(0))
        print(address)
    except:
        print('爬取失败')

def main():
    getGuideHTML()

if __name__ == '__main__':
    main()

