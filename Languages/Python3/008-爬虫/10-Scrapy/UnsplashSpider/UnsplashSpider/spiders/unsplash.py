# -*- coding: utf-8 -*-
import scrapy


class UnsplashSpider(scrapy.Spider):
    name = 'unsplash'
    allowed_domains = ['unsplash.com']
    start_urls = ['https://unsplash.com/s/photos/illustration/']

    def start(self):
        self.cookie = {
            'ugid': 'f2f6ea88945a60072330d04bb831c21c5285136',
            'uuid': '2713afe0-723b-11ea-9d31-8dcd43a85c22',
            'xpos': '%7B%7D',
            '_ga': 'GA1.2.1378874382.1585540970',
            '_sp_ses.0295': '*',
            '_gid': 'GA1.2.1190325733.1586245149'
#            '_sp_id.0295': 'f7e60e64-8182-4d80-aa1e-660dc8a58608.1585540898.9.1586247348.1586137163.ab1f9ba3-b44b-476f-b827-5d47e7410128',
        }

        self.header = {
            'cache-control': 'max-age=0',
            'accept-language': 'zh-CN,zh;q=0.9,en;q=0.8',
            'accept': 'text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9',
            'user-agent': 'Mozilla/5.0 (Macintosh; Intel Mac OS X 10_14_6) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.163 Safari/537.36',
        }
        try:
            yield scrapy.Request(url = start_urls, headers = self.header, callback = self.parse)
            self.log('Main site Done.')
        except:
            self.log('Main site Failed.')

    def parse(self, response):
        filename = './text.html'
        # self.log(filename)
        with open(filename, 'wb') as f:
           f.write(response.body)
        # self.log(response.body)
        self.log(response.xpath('./img@srcSet'))
