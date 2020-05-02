# -*- coding: utf-8 -*-
import scrapy


class ToscrapeXpathSpider(scrapy.Spider):
    name = 'toscrape-xpath'
    allowed_domains = ['quotes.toscrape.com']
    start_urls = ['http://quotes.toscrape.com/']

    def parse(self, response):
        for quote in response.xpath('//div[@class = "quote"]'):
            yield {
                    'text' : response.xpath('./span[@class="text"]/text()').extract_first(),
                    'author' : response.xpath('.//small[@class="author"]/text()').extract_first(),
                    'tags' : response.xpath('.//div[@class="tags"]/a[@class="tag"]/text()').extract(),
                    }
        next_page_url = response.xpath('//li[@class="next"]/a/@href').extract_first()
        if next_page_url is not None:
            yield scrapy.Request(response.urljoin(next_page_url))
