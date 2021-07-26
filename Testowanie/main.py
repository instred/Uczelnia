import urllib.request
import time
from pathlib import Path

from selenium import webdriver
from selenium.webdriver.chrome.options import Options
from selenium.webdriver.support.select import Select


def z4():

    driverek = webdriver.Chrome(executable_path='C:\TestFiles\chromedriver.exe')
    driverek.get('https://en.wikipedia.org')
    searched = driverek.find_element_by_id('searchInput')
    searched.send_keys('python')
    buttonn = driverek.find_element_by_id('searchButton')
    buttonn.click()

    for a in driverek.find_elements_by_xpath("//*[contains(@href,'Python')]"):

        second_pag = a.get_attribute('href')
        driverek.execute_script("window.open('" + second_pag + "');")
        driverek.switch_to.window(driverek.window_handles[1])
        path = "//p"
        par = driverek.find_element_by_xpath(path).text
        print(driverek.title + '\n' + par + '\n')
        time.sleep(2)
        driverek.close()
        driverek.switch_to.window(driverek.window_handles[0])
        time.sleep(2)

    driverek.close()


def z3():

    driver2 = webdriver.Chrome(executable_path='C:\TestFiles\chromedriver.exe')
    driver2.get('https://en.wikipedia.org')
    search = driver2.find_element_by_id('searchInput')
    search.send_keys('python')
    button = driver2.find_element_by_id('searchButton')
    button.click()

    for a in driver2.find_elements_by_xpath("//*[contains(@href,'Python')]"):
        second_page = a.get_attribute('href')
        driv = webdriver.Chrome(executable_path='C:\TestFiles\chromedriver.exe')
        driv.get(second_page)
        path = "//p"
        par = driv.find_element_by_xpath(path).text
        print(driv.title + '\n' + par + '\n')
        time.sleep(2)
        driv.close()


def z2():

    options = Options()
    options.headless = True
    options.add_argument("download.default_directory=")
    driveer = webdriver.Chrome(options=options, executable_path='C:\TestFiles\chromedriver.exe')
    driveer.get('file:///C:/Users/jakub/Desktop/Testowanie/page/index.html')
    subpage = driveer.find_element_by_link_text('Gallery')
    subpage.click()
    images = driveer.find_elements_by_class_name("gallery")
    iterator = 0
    
    Path("C:/Users/jakub/Desktop/Testowanie/downloaded_images").mkdir(parents=True, exist_ok=True)
    
    for image in images:
        src = image.get_attribute('src')
        if iterator == 0:
            png_name = src[54:-5]
        else:
            png_name = src[54:-4]
        print(png_name)
        urllib.request.urlretrieve(src, 'downloaded_images/' + png_name + '.png')
        iterator += 1


def z1():

    drive = webdriver.Chrome(executable_path='C:\TestFiles\chromedriver.exe')
    drive.get('file:///C:/Users/jakub/Desktop/Testowanie/page/index.html')

    subpage = drive.find_element_by_link_text('Contact')
    subpage.click()
    #data input + country selection
    drive.find_element_by_name("name").send_keys("jola")
    drive.find_element_by_name("surname").send_keys("nielojalna")
    drive.find_element_by_name("email").send_keys("jolka123@gmail.com")
    selector = Select(drive.find_element_by_name("country"))
    selector.select_by_value("germany")
    drive.find_element_by_name("message").send_keys("essa")
    #ss
    drive.save_screenshot('form.png')
    #submit
    submit = drive.find_element_by_id("contact_form")
    submit.submit()
    #alert
    time.sleep(2)
    drive.switch_to.alert.accept()

if __name__ == "__main__":
    #z1()
    #z2()
    #z3()
    z4()