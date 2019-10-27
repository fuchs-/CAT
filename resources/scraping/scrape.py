import requests
from bs4 import BeautifulSoup as BS
from openpyxl import Workbook

def getPrimaryAttributes(row):
    divs = row.div.find_all("div")[3:6]
    ret = []
    for div in divs:
        ret.extend(div.text.split(" + "))
    return ret

def getSecondaryAttributes(row):
    tbody = row.tbody
    trs = tbody.find_all("tr")
    ret = []
    for i in range(1, len(trs)):
        ret.append(trs[i].td.text.strip())
    return ret
    
def getTerciaryAttributes(row):
    trs = row.tbody.find_all("tr")
    res = []
    for i in range(len(trs)-2):
        res.append(trs[i].td.text.strip())
    return res
    

def scrape(url):
    req = requests.get(url)

    if req.status_code != 200:
        print("Problem with web request: " + req.status_code)
        return None

    soup = BS(req.text, "html.parser")
    table = soup.find("table", { "class":"infobox"} )
        
    trs = table.find_all("tr")
        
    res = getPrimaryAttributes(trs[2])
    res.extend(getSecondaryAttributes(trs[3]))
    res.extend(getTerciaryAttributes(trs[15]))
    
    return res
        
with open("names.txt", 'r') as file:
    names = file.read().split("\n")
names.pop()

base_url = "https://dota2.gamepedia.com/"

wb = Workbook()
ws = wb.active

for name in names:
    ws.append([name] + scrape(base_url + name))
    print("%s scraped" % name)

wb.save("dota2_heroes.xlsx")
