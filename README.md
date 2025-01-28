WIP Proxy Tool.

Functions
-Proxy Scraping
-Proxy Checking HTTPs/Socks4/Socks5
-Host private Rotating Proxy List
-Settings for Tool
-Information

Proxy Scraper [Working (Unfinished)]
Scrapes Websites async -> Tested 879 -> 171k Proxies -> Took 1.4sec
Remove Dupe from Scraped before saving
Display Amount Scraped per site + Total
Display Status of Scraping -> Success | Failed | Timeout | Empty | Invalid

Proxy Checker [WIP (Unfinished)]
Drag & Drop File to Check
Display Good/Bad Proxy
Check only Sock5 currently for testing purpose (will update asap)

Host Rotating [Not Implemented]
-

Settings [WIP (Unfinished)]
Timeout for Scraper
Remove Duplicates while Scraping


TO-DO

Proxy Scraper
Add Threads for better resource usage
Add ability to Scrape weblinks to scrape multiple layers
Add ability to auto-remove invalid weblinks -> e.g http://zi1.zeroredirect1.com/zcvisitor/8...a80d05e7e1
Add UI for status progress of parsed Proxies from URLs -> Progress [||||||-47%-----] | Valid URLs: 71 | Invalid: 29 | Ratio: 71.0% | 29.0%.
Add ability to limit total scrape amount per usage
Add ability to check scraped proxies automatically
Update method for file saving
Update Interface for stats

Proxy Checker
Add ability to automatically check HTTP/s, Socks4, Socks5
Add UI for status progress of checked Proxies in list -> Progress [|||||--34%-----] | Valid: 3928 | Invalid: 8391 | Ratio: 31.9% | 68.1%.
Add ability to save in seperate .txt files -> HTTPs.txt, Socks4.txt, Socks5.txt, All.txt, AllSocks.txt

Host Rotating
Add ability to Host Proxylist on local browser
Add ability to update Proxies hosted without downtime for usage as rotating proxy -> eg. localhost:8000 in Application becomes new IP:PORT on every request
Add ability to run Proxy Scraper & Checker in background to auto-add/check hosted proxies
Add UI for statistics -> Type: Socks4 | Amount: 3921 | Usage/sec: 91 proxies/s | Time since last update: 01:31min

Settings
Add Display for Settings to be visible before selecing for changing -> [1] Timeout | Current: 7s
Add ability to reset Settings to default

 
