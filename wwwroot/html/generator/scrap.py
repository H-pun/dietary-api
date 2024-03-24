import json
import requests
from bs4 import BeautifulSoup

class Food:
    def __init__(self, name, url):
        self.name = name
        self.url = url
        
def scrape_fatsecret(foods):
    for food in foods:        
        response = requests.get(food.url)
        if response.status_code == 200:
            soup = BeautifulSoup(response.content, 'html.parser')
            header = soup.find(class_='summarypanelcontent')
            web_name = header.find('h1').text.strip()
            portion = header.find('h2')
            portion_detail = portion.contents[0].text[2:].capitalize().strip()
            if portion.span:
                portion_detail += f" {portion.span.text.strip().replace(' ', '')}"

            prop_alias = {
                "Kal": "calories",
                "Lemak": "fat",
                "Karb": "carbohydrate",
                "Prot": "protein"
            }
            data = {
                "web_name": web_name,
                "name": food.name,
                "unit": portion_detail,
                "url": food.url
            }
            nutrients = soup.find('div', class_='factPanel')
            for fact in nutrients.find_all('td', class_='fact'):
                data[prop_alias[fact.find(class_='factTitle').text.strip()]] = float(fact.find(class_='factValue').text.replace(',', '.').rstrip("g").strip())

            # Konversi ke JSON
            json_output = json.dumps(data, indent=4)

            # Print output
            print(json_output)

        else:
            print("Failed to retrieve data. Status code:", response.status_code)


if __name__ == "__main__":
    foods = [
        Food("Ayam Bakar", "https://www.fatsecret.co.id/kalori-gizi/umum/paha-ayam-panggang-(kulit-dimakan)?portionid=6417&portionamount=1,000"),
        Food("Ayam Goreng", "https://www.fatsecret.co.id/kalori-gizi/umum/paha-ayam-goreng-tanpa-pelapis-(kulit-dimakan)?portionid=5675&portionamount=1,000"),
        Food("Bakso", "https://www.fatsecret.co.id/kalori-gizi/umum/bakso-daging-sapi?portionid=570240&portionamount=1,000"),
        Food("Bakwan", "https://www.fatsecret.co.id/kalori-gizi/umum/bakwan?portionid=5125714&portionamount=1,000"),
        # Food("Batagor", "https://example.com/batagor"),
        # Food("Bihun", "https://example.com/bihun"),
        # Food("Capcay", "https://example.com/capcay"),
        # Food("Gado-Gado", "https://example.com/gado_gado"),
        # Food("Ikan Goreng", "https://example.com/ikan_goreng"),
        # Food("Kerupuk", "https://example.com/kerupuk"),
        # Food("Martabak Telur", "https://example.com/martabak_telur"),
        # Food("Mie", "https://example.com/mie"),
        # Food("Nasi Goreng", "https://example.com/nasi_goreng"),
        # Food("Nasi Putih", "https://example.com/nasi_putih"),
        # Food("Nugget", "https://example.com/nugget"),
        # Food("Opor Ayam", "https://example.com/opor_ayam"),
        # Food("Pempek", "https://example.com/pempek"),
        # Food("Rendang", "https://example.com/rendang"),
        # Food("Roti", "https://example.com/roti"),
        # Food("Sate", "https://example.com/sate"),
        # Food("Sosis", "https://example.com/sosis"),
        # Food("Soto", "https://example.com/soto"),
        # Food("Steak", "https://example.com/steak"),
        # Food("Tahu", "https://example.com/tahu"),
        # Food("Telur", "https://example.com/telur"),
        # Food("Tempe", "https://example.com/tempe"),
        # Food("Terong Balado", "https://example.com/terong_balado"),
        # Food("Tumis Kangkung", "https://example.com/tumis_kangkung"),
        # Food("Udang", "https://example.com/udang")
    ]

    scrape_fatsecret(foods)
