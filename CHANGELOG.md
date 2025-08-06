# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/),
and this project adheres to [Semantic Versioning](https://semver.org/).

## [1.2.0] - 2025-08-06
### Added
- Экспорт объекта CKO_DATA в файл формата *.keepkcs11 (БЕЗ ШИФРОВАНИЯ)
- Импорт объекта CKO_DATA из файла формата *.keepkcs11

### Fixed
- Исправлен баг с чтением ключа из устройств с двумя апплетами (JaCarta 2 PKI/ГОСТ)

## [1.1.0] - 2025-07-25

### Fixed
- Генерация ключевого значения происходит средствами KeePass, что гораздо безопаснее.

## [1.0.0] - 2025-07-05
### Added
- Выбор PKCS#11 библиотеки и вывод списка доступных слотов
- Чтение списка объектов CKO_DATA из выбранного слота
- Создание объекта CKO_DATA в выбранном слоте
- Чтение CKA_VALUE объекта CKO_DATA и использование его в качестве ключевого значеения
- При открытии существующей базы запрашивается пароль для слота, с которого читался ключ для этой базы

### Deprecated
- Генерация ключевого значения происходит через функцию Random(). Недочет будет исправлен в версии 1.1.