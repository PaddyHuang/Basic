import requests
from bs4 import BeautifulSoup
import bs4

def getHTMLText(url):
    try:
        r = requests.get(url, timeout = 10)
        r.raise_for_status( )
        r.encoding = r.apparent_encoding
        return r.text
    except:
        return ""

def fillUnivList(uList, html):
    soup = BeautifulSoup(html, 'html.parser')
    for tr in soup.find('tbody').children:
        if isinstance(tr, bs4.element.Tag):
            tds = tr('td')  # tr.find_all(''td)
            uList.append([tds[0].string, tds[1].string, tds[3].string])

def printUnivList(uList, num):
    tplt = '{0:^10}\t{1:{3}^10}\t{2:^10}'
    print(tplt.format('排名', '大学名称', '总分', chr(12288)))
#    print(tplt.format('Ranking', 'University', 'Score', chr(12288)))
    for i in range(num):
        u = uList[i]
        print(tplt.format(u[0], u[1], u[2], chr(12288)))

def main():
    uinfo = []
    url = 'http://www.zuihaodaxue.com/Greater_China_Ranking2019_0.html'
    html = getHTMLText(url)
    fillUnivList(uinfo, html)
    printUnivList(uinfo, 20)    # print 20 univ

if __name__ == '__main__':
    main()
