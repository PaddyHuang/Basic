# https://unsplash.com/

# https://unsplash.com/photos/CYvbt621yLE
# https://unsplash.com/photos/CYvbt621yLE/download?force=true

import requests, re, os, traceback
from bs4 import BeautifulSoup

cookie = {
            'ugid': 'f2f6ea88945a60072330d04bb831c21c5285136',
            'uuid': '2713afe0-723b-11ea-9d31-8dcd43a85c22',
            'xpos': '%7B%7D',
            '_ga': 'GA1.2.1378874382.1585540970',
            '_sp_ses.0295': '*',
            '_gid': 'GA1.2.1190325733.1586245149'
#            '_sp_id.0295': 'f7e60e64-8182-4d80-aa1e-660dc8a58608.1585540898.9.1586247348.1586137163.ab1f9ba3-b44b-476f-b827-5d47e7410128',
}

header = {
            'cache-control': 'max-age=0',
            'accept-language': 'zh-CN,zh;q=0.9,en;q=0.8',
            'accept': 'text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9',
            'user-agent': 'Mozilla/5.0 (Macintosh; Intel Mac OS X 10_14_6) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.163 Safari/537.36',
}
 
def getHTMLText(url):
    try:
        response = requests.get(url, headers = header, cookies = cookie, verify = True)
        response.raise_for_status()
        response.encoding = response.apparent_encoding
        return response.text
    except:
        print('Scrape failed')
        return ''

def parseHTML(html):
    count = 0
    if html == '':
        return []

    soup = BeautifulSoup(html, 'html.parser')
    list = soup.find_all('a', attrs = {'title' : 'Download photo'})
    res = []
    for i in range(len(list)):
        pic = re.findall(r'https://.*?force=true', str(list[i]))
        res.append(pic[0])
        count += 1
        print('\r获取进度: {:.2f}'.format(count * 100 / len(list)), end = '')
    print()
    return res

def download(downList):
    count = 0
#    root = '/Users/Polin/Pictures/Unsplash/'
    root = '/home/pi/Pictures/Unsplash/'
    try:
        if not os.path.exists(root):
            os.mkdir(root)
        for item in downList:
            path = root + item.split('/')[-2] + '.png'
            if not os.path.exists(path):
                r = requests.get(item, headers = header, cookies = cookie)
                with open(path, 'wb') as f:
                    f.write(r.content)
                    count += 1
                    print('\r下载进度: {:.2f}'.format(count * 100 / len(downList)), end = '')
        print()
    except:
        traceback.print_exc()
        print('Download failde')

def main():
    url = 'https://unsplash.com/'
    html = getHTMLText(url)
    list = parseHTML(html)
#    print(list)
    download(list)
    print('Download Completed')

if __name__ == '__main__':
    main()
