# 第一个东方财富网列表找不到的话这个链接
# http://quote.eastmoney.com/stock_list.html#sh
# 第二个百度股票找不到用这个网站代替
# http://so.cfi.cn/so.aspx?txquery=sz501310 （等号后这个sz501301是对应每个股的代号，对应老师例子中百度股票网址后面加的一串）

import requests, re
import traceback
from bs4 import BeautifulSoup

def getHTMLText(url, header):
    try:
        r = requests.get(url, headers = header, timeout = 10)
        r.raise_for_status()
        r.encoding = r.apparent_encoding
        return r.text
    except:
        print('爬取失败')
        return ""

def getStockList(lst, stockURL):

    html = getHTMLText(stockURL, header)
    soup = BeautifulSoup(html, 'html.parser')
    a = soup.find_all('a')
    for i in a:
        try:
            href = i.attrs['href']
            lst.append(re.findall(r's[hz]\d{6}', href)[0])
        except:
            continue

def getStockInfo(lst, stockURL, fpath):
    count = 0
    for stock in lst:
        url = stockURL + stock + '.html'
        html = getHTMLText(url)
        try:
            if html == '':
                continue
            infoDict = {}
            soup = BeautifulSoup(html, 'html.parser')
            stockInfo = soup.find('div', attrs = {'class' : 'stock-bets'})
            name = stockInfo.find_all(attrs = {'class' : 'bets-name'})[0]
            infoDict.update({'股票名称' : name.text.split()[0]})

            keyList = stockInfo.find_all('dt')
            valueList = stockInfo.find_all('dd')
            for i in range(len(keyList)):
                key = keyList[i].text
                value = valueList[i].text
                infoDict[key] = value

            with open(fpath, 'a', encoding = 'utf-8') as f:
                f.write(str(infoDict) + '\n')
                count = count + 1
                print('\r当前进度: {:.2f}'.format(count * 100 / len(lst)), end = '')
        except:
            traceback.print_exc()
            print('\r当前进度: {:.2f}'.format(count * 100 / len(lst)), end = '')
            continue

def main():
    stock_list_url = 'http://quote.eastmoney.com/stock_list.html'
    stock_info_url = 'http://so.cfi.cn/so.aspx?txquery='
    output_file = '/User/Polin/Downloads/stock.txt'
    slist = []
    getStockList(slist, stock_list_url)
    getStockInfo(slist, stock_info_url, output_file)

if __name__ == '__main__':
    main()
