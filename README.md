![logo](./.images/pkcs11_for_repo.png)

KeePKCS11 это простой плагин для оригинального [KeePass](https://keepass.info/), добавляющий ключевой поставщик, взаимодействующий с pkcs#11 библиотекой для ваших криптографический токенов.

Плагин **НЕ** реализует ассиметричное шифрование или любое другое взаимодействие с сертификатами. Вместо этого он создает/читает объекты данных (CKO_DATA), которые KeePass испольует для симетричного шифрования.

Плагин использует C# библиотеку [Pkcs11Interop](https://github.com/Pkcs11Interop/Pkcs11Interop). Вы так же можете вручную создавать объекты и делать их резервную копию, используя [Pkcs11Admin](https://github.com/Pkcs11Admin/Pkcs11Admin).

Свойства ключевого объекта:
 - CKA_CLASS: 		CKO_DATA
 - CKA_TOKEN: 		True
 - CKA_PRIVATE:		True 
 - CKA_MODIFIABLE:	False
 - CKA_LABEL:		**Custom**
 - CKA_VALUE:		**Custom byte array**


## Сборка

Официальная [инструкция по созданию плагинов](https://keepass.info/help/v2_dev/plg_index.html) гласит:

Выполнять команду в "cmd.exe" (пути условны)

`C:\keepass\KeePass.exe --plgx-create C:\repos\KeePKCS11\KeePKCS11`

В конечном каталог "KeePKCS11" должен находиться "KeePKCS11.csproj", иначе компилятор KeePass выдаст ошибку

Будет создан файл "D:\repos\KeePKCS11.plgx"

И всё... Открывать проект, достраивать зависимости к пространству имен KeePass НЕ ОБЯЗАТЕЛЬНО.
Компилировать проект средствами Visual Studio НЕ НУЖНО, каталоги ".\KeePKCS11\bin\Debug" и ".\KeePKCS11\bin\Release" должны быть пустыми!

## Совместимость
### Платформа

На текущий момент плагин работает только в среде Windows. Работа в среде linux из под Mono возможно появится, но не гарантируется.

### PKCS#11 токены

[PASS] - плагин полностью совместим с этим устройством.

[MOST LIKELY] - производителем заявлена поддержка стандарта PKCS#11, но у меня просто нет возможности это проверить.

#### [Aladdin R.D. JaCarta Единый Клиент](https://www.aladdin-rd.ru/support/downloads/jacarta_client)
* JaCarta PKI [PASS]
* JaCarta-2 ГОСТ [PASS]
* JaCarta-2 PKI/ГОСТ (видит оба апплета одновременно) [PASS]
* eToken PRO (Java) [PASS]

#### [Aladdin R.D. eToken PKI Client 5.1 SP1](https://erim.ru/gde-skachat-i-kak-ustanovit-drayvery-etoken.html)
* eToken ГОСТ [PASS]
* eToken PRO (Java) [PASS]

#### [Aktiv Rutoken](https://www.rutoken.ru/support/download/windows/)
* Рутокен Lite [PASS]
* Рутокен ЭЦП 2.0 / 3.0 [PASS]

#### [ESMART PKI Client](https://token.esmart.ru/downloads)
* ESMART Token [MOST LIKELY]
* ESMART Token ГОСТ [MOST LIKELY]

#### [Safenet Authentication Client](https://knowledge.digicert.com/general-information/how-to-download-safenet-authentication-client)
* SafeNet eToken 5110 [MOST LIKELY]
* eToken PRO (Java) [MOST LIKELY]

Постепенно в списке будут появляться другие другие устройста.

