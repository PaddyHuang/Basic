# taobao search link for 书包
# Page 1: https://s.taobao.com/search?q=%E4%B9%A6%E5%8C%85&imgfile=&commend=all&ssid=s5-e&search_type=item&sourceId=tb.index&spm=a21bo.2017.201856-taobao-item.1&ie=utf8&initiative_id=tbindexz_20170306
# Page 2: https://s.taobao.com/search?q=%E4%B9%A6%E5%8C%85&imgfile=&commend=all&ssid=s5-e&search_type=item&sourceId=tb.index&spm=a21bo.2017.201856-taobao-item.1&ie=utf8&initiative_id=tbindexz_20170306&bcoffset=3&ntoffset=3&p4ppushleft=1%2C48&s=44
# Page 3: https://s.taobao.com/search?q=%E4%B9%A6%E5%8C%85&imgfile=&commend=all&ssid=s5-e&search_type=item&sourceId=tb.index&spm=a21bo.2017.201856-taobao-item.1&ie=utf8&initiative_id=tbindexz_20170306&bcoffset=0&ntoffset=6&p4ppushleft=1%2C48&s=88

import requests, re

def getHTMLText(url):
    try:
        header = {
            'authority': 's.taobao.com',
            'cache-control': 'max-age=0',
            'pragma': 'no-cache',
            'dnt': '1',
            'upgrade-insecure-requests': '1',
            'user-agent': 'Mozilla/5.0 (Macintosh; Intel Mac OS X 10_14_6) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.149 Safari/537.36',
            'sec-fetch-dest': 'document',
            'accept': 'text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9',
            'sec-fetch-site': 'same-origin',
            'sec-fetch-mode': 'navigate',
            'sec-fetch-user': '?1',
            'referer': 'https://www.taobao.com/',
            'accept-language': 'zh-CN,zh;q=0.9,en;q=0.8',
            'cookie': 'thw=cn; cna=HLHqFqxFUxcCAWdi8A4nCewv; cookie2=1e6d887de863bb2567ac4ddfec3c0a41; t=acad1f83fdf6a7813cc72425366cef89; _tb_token_=e4e83e77be031; _samesite_flag_=true; v=0; sgcookie=EveguIeLRJl1QIDq8BIZg; unb=2366249553; uc3=nk2=tPEAlueyNGP%2B5xtnDNY%3D&lg2=UtASsssmOIJ0bQ%3D%3D&id2=UUtNhmBGX7200Q%3D%3D&vt3=F8dBxdAVV%2FwnyeyzvO0%3D; csg=28a89e74; lgc=%5Cu6700%5Cu7231acegodness; cookie17=UUtNhmBGX7200Q%3D%3D; dnk=%5Cu6700%5Cu7231acegodness; skt=fc07856a85841ba6; existShop=MTU4NjE4MjgwNg%3D%3D; uc4=id4=0%40U2l3zW38C12iqReoLLi2SgYELWg2&nk4=0%40thfpDW6Kgfqj1D27dphM1mEKM4LZnSoYiQ%3D%3D; tracknick=%5Cu6700%5Cu7231acegodness; _cc_=VFC%2FuZ9ajQ%3D%3D; tg=0; _l_g_=Ug%3D%3D; sg=s3e; _nk_=%5Cu6700%5Cu7231acegodness; cookie1=BxIfTtpz%2FFcxi2Pkw36CC5TEt80zYjbz6lzESlA3%2FQk%3D; tfstk=cCLfBPqvKdLyiI2OPKGP0ZcFDYQNZue5Zm6yG33kjbnUXFAfik4FdU86j8aRv_1..; mt=ci=46_1; enc=TjGFBIqqWDhs%2FEsEJBDU59nWLk8OYldxmKz3Zp6Rdaq0WArQ99kHkWBXHDjpSdg1aRQ35ljFBxjgScbWKGwxaA%3D%3D; alitrackid=www.taobao.com; lastalitrackid=www.taobao.com; hng=CN%7Czh-CN%7CCNY%7C156; uc1=cookie14=UoTUPOVUv6dHHw%3D%3D&lng=zh_CN&cookie16=VT5L2FSpNgq6fDudInPRgavC%2BQ%3D%3D&existShop=false&cookie21=Vq8l%2BKCLjhS4UhJVbhgU&tag=8&cookie15=Vq8l%2BKCLz3%2F65A%3D%3D&pas=0; l=dBIOKteRQm7I57CkBOfaZbdCKEQTaQAfhPVy2oVkPIB1t3C0uKGahHweFZVHE3QLEtfE_etPKYL5idhM8P43WvMDBeYBRs5mpxvOI; isg=BISEfY1KhvwkBzIwdy2yHV3yVQR2nagHiEreO54nSc3lySKTxqyMlqcrDGERaeBf; JSESSIONID=D38A1ECAF79C9AE2B14362E10690A5A8',
        }
        r = requests.get(url, headers = header)
        r.raise_for_status()
        r.encoding = r.apparent_encoding
#        print(r.text)
        return r.text
    except:
        print('爬取失败')
        return ''

def parsePage(itemList, html):
    try:
        priceList = re.findall(r'"view_price":"[\d.]*"', html)
        titleList = re.findall(r'"raw_title":".*?"', html)
        for i in range(len(priceList)):
            price = eval(priceList[i].split(':')[1])
            title = eval(titleList[i].split(':')[1])
            itemList.append([title, price])
    except:
        print('解析出错')

def printGoodsList(itemList):
    tplt = '{:4}\t{:8}\t{:16}'
    print(tplt.format('序号', '价格', '商品名称'))
    count = 0
    for item in itemList:
        count = count + 1
        print(tplt.format(count, item[0], item[1]))

def main():
    goods = '书包'
    depth = 2
    start_url = 'https://s.taobao.com/search?q=' + goods
    infoList = []
    for i in range(depth):
        try:
            url = start_url + '&s=' + str(44 * i)
            html = getHTMLText(url)
            parsePage(infoList, html)
        except:
            continue
    printGoodsList(infoList)

if __name__ == '__main__':
    main()
