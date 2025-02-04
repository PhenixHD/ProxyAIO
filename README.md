# Proxy AIO Tool

## This Tool is currently broken and will be re-coded from ground due to newly obtained programming knowledge.


`This is a learning project. Bad code and inefficient reource usage is expected.
This project is WIP and will often be updated with unfinished/broken code for the sake of saving progress.`

<img src="https://github.com/user-attachments/assets/7a87369a-9594-4db3-9c1f-2f28091edfcb" alt="Main Menu" width="500" height="300">
<img src="https://github.com/user-attachments/assets/cc1d2b0f-fb4c-4c40-958e-7e6beb9e310a" alt="Proxy Scraper" width="500" height="300">

## Features

### ✅ **Proxy Scraping**
- **Asynchronous website scraping** (879 websites tested; 171k proxies scraped in 1.4 seconds)
- **Remove duplicates** from scraped proxies before saving
- Display the **amount of proxies scraped** per site and the **total** count
- **Scraping Status Indicators**:
  - **Success**
  - **Failed**
  - **Timeout**
  - **Empty**
  - **Invalid**

### ✅ **Proxy Checking (HTTPS, Socks4, Socks5)**
- **Drag & Drop** file support to check proxies
- Displays proxy results as **Good/Bad Proxy**
- Currently supports **Socks5** for testing (other protocols will be added soon)

### ✅ **Host Rotating Proxy List**
- (Not implemented yet – work in progress)

### ✅ **Settings Configuration**
- Customize timeout settings for the scraper
- Option to automatically **remove duplicates** during scraping

### ✅ **Information Display**
- View key details about your current setup, stats, and configurations

---

## Development Progress

### 🚧 **Proxy Scraper** (Unfinished)
- **Next Steps**:
  - Add **multi-threading** for better resource usage
  - Scrape **multiple layers** of URLs
  - Automatically **remove invalid links** (e.g., `http://zi1.zeroredirect1.com/zcvisitor/8...a80d05e7e1`)
  - Add UI for showing **scraping progress**:
    - Example: `Progress [||||||-47%] | Valid URLs: 71 | Invalid: 29 | Ratio: 71.0% | 29.0%`
  - Add ability to **limit total scrape amount** per session
  - Automatically **check scraped proxies**
  - Update **file saving methods**
  - Revise **stats interface**

### 🚧 **Proxy Checker** (WIP)
- **Next Steps**:
  - Add support for automatic checking of **HTTP/s**, **Socks4**, and **Socks5** proxies
  - Add UI for displaying **proxy check progress**:
    - Example: `Progress [|||||--34%] | Valid: 3928 | Invalid: 8391 | Ratio: 31.9% | 68.1%`
  - Save results into separate `.txt` files:
    - `HTTPs.txt`
    - `Socks4.txt`
    - `Socks5.txt`
    - `All.txt`
    - `AllSocks.txt`

### 🚧 **Host Rotating Proxy List** (Not Implemented)
- **Next Steps**:
  - Host the rotating proxy list on a **local server** (e.g., `localhost:8000`)
  - Update proxies without **downtime** for seamless rotation (e.g., new IP:PORT with each request)
  - Add background functionality to **scrape & check proxies** automatically for rotation
  - Add a UI for displaying **proxy usage stats**:
    - Example: `Type: Socks4 | Amount: 3921 | Usage/sec: 91 proxies/s | Time since last update: 01:31min`

### 🚧 **Settings** (WIP)
- **Next Steps**:
  - Display current settings before editing (e.g., `Timeout | Current: 7s`)
  - Add option to **reset settings** to default

---

## Installation & Usage

1. Clone the repository:
   ```bash
   git clone https://github.com/PhenixHD/ProxyAIO.git
   cd ProxyAIO
