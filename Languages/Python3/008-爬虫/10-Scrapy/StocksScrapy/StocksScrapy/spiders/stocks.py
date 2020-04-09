# -*- coding: utf-8 -*-
import scrapy
import re

class StocksSpider(scrapy.Spider):
    name = 'stocks'
    # allowed_domains = ['http://so.cfi.cn/so.aspx?txquery=']
    # start_urls = ['http://so.cfi.cn/so.aspx?txquery=/']
    start_urls = ['http://quote.eastmoney.com/stock_list.html#sh']

    def parse(self, response):
        for href  in response.css('a::attr(href)').extract():
            try:
                stock = re.findall(r'[s][hz]\d{6}', href)[0]
                url = 'http://so.cfi.cn/so.aspx?txquery=' + stock
                yield scrapy.Request(url, callback = self.parse_stock)
            except:
                continue

    def parse_stock(self, response):
        infoDict = {}
        stockInfo = response.css('.quote')
        name = stockInfo.css('td').extract()[0]
        keyList = stockInfo.css('td').extract()
        valueList = stockInfo.css('span').extract()
        for i in range(len(keyList)):
            infoDict[keyList[i]] = valueList[i]
        yield infoDict

