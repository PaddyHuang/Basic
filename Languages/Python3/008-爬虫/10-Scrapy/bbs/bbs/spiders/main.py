# -*- coding: utf-8 -*-
import scrapy


class MainSpider(scrapy.Spider):
    name = 'main'
    allowed_domains = ['pornbbs2048.com/']

    def start_requests(self):
        start_urls = ['http://pornbbs2048.com/']
        self.header = {
            'User-Agent': 'Mozilla/5.0 (Macintosh; Intel Mac OS X 10_14_6) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.163 Safari/537.36'
        }
 
        for url in start_urls:
            try:
                yield scrapy.Request(url = url, headers = self.header, callback = self.parse)
            except:
                continue

    def parse(self, response):
        urls = response.xpath('.//a/@href').extract()[:4]
        self.log(urls)
        for url in urls:
            try:
                yield scrapy.Request(url = url, headers = self.header, callback
                        = self.parseMain, dont_filter = True)
                break   # making it once is enough
            except:
                self.log('Failed')
                continue
        # with open(filename, 'wb') as f:
        #    f.write(urls)

    def parseMain(self, response):
        url = response.url
        a = response.xpath('.//th/span/a/@href').extract()[16:-8]
        self.log(a)
        # self-photo
        try:
            self.log(url + a[9])
            yield scrapy.Request(url = url+a[9], headers = self.header, callback =
                    self.parseSF, dont_filter = True)
        except:
            pass

    def parseSF(self, response):
        url = response.url
        subject = response.xpath('.//a[@class = "subject"]').extract()
        self.log(url + subject[6])
#        self.log(subject)

