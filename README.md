# MyLittleVault
Программа для быстрого поиска и копирования паролей и дополнительной информации.
- Прячется в трее
- При клике на конечные активные пункты меню копирует информацию в буфер обмена.
- У пунктов с типом Hidden не отображается хранимое значение, например, чтобы не показывать пароли при демонстрации экрана на конференциях.
- Может с помощью пароля (до 32 символов) зашифровать файл алгоритмом AES-256 для защищенной передачи файла, например, по Email.
- Есть встроенный механизм автозапуска.

![Скрин](https://i.imgur.com/Qb7Kfvh.png)

## Описание JSON файла данных
### Структура элементов
- Name - название элемента, отображается всегда.
- Type - тип элемента (Text, Hidden, Folder).
- Enabled - активен ли пункт меню, отображает только название (для Type=Folder и Enabled=false подменю также не генерируются).
- Value - значение элемента, что будет скопировано в буфер при нажатии (не для Type=Folder).
- Childs - дочерние объекты (только для Type=Folder).

Можно не указывать несовместимые параметры. 
- Т.е. если Type=Folder, значение из Value ничего не делает. 
- И наоборот, если Type=Text или Type=Hidden, Childs ни на что не влияет.
- Enabled по умолчанию true, т.е. имеет смысл указывать только Enabled=false, для пунктов, которые необходимо деактивировать.


### Типы элементов
- Text - отображает и название и значение в пункте меню в формате "Название: Значение". При клике копирует значение в буфер.
- Hidden - отображает только название, можно использовать, чтобы не светить пароли на конференциях. При клике копирует значение в буфер.
- Folder - пункт с подменю, если дочерние элементы указаны в Childs. При клике ничего не делает (разве что, чуть быстрее открывает подменю).


### Пример
- Проект 1 (подменю)
  - Логин: myLogin (отображается и название и значение)
  - Пароль: mySecretPassword (отображается только название)
- Проект 2 (подменю)
  - Логин: myLogin2 (отображается и название и значение)
  - Пароль: mySecretPassword2 (отображается только название)
  - Доп инфа (подменю)
    - Релиз по ПН, ЧТ (отображается название, неактивно)
    - URL: https://github.com/alextrof94/MyLittleVault (отображается и название и значение)
    
RootItems - обязательный сервисный массив.
```
{
  "RootItems": [
    {
      "Name": "Проект 1",
      "Type": "Folder",
      "Childs": [
        {
          "Name": "Логин",
          "Type": "Text",
          "Value": "myLogin"
        },
        {
          "Name": "Пароль",
          "Type": "Hidden",
          "Value": "mySecretPassword"
        },
      ]
    },
    {
      "Name": "Проект 2",
      "Type": "Folder",
      "Childs": [
        {
          "Name": "Логин",
          "Type": "Text",
          "Value": "myLogin2"
        },
        {
          "Name": "Пароль",
          "Type": "Hidden",
          "Value": "mySecretPassword2"
        },
        {
          "Name": "Доп инфа",
          "Type": "Folder",
          "Childs": [
            {
              "Name": "Релиз по ПН, ЧТ",
              "Type": "Hidden",
              "Enabled": "false"
            },
            {
              "Name": "URL",
              "Type": "Text",
              "Value": "https://github.com/alextrof94/MyLittleVault"
            },
          ]
        },
      ]
    },
  ]
}
```
### Костыль
Для удобного чтения многострочного пункта меню в JSON, можно использовать переводы строк в середине строкового значения:
```
{
  "Name": "Lorem ipsum dolor sit amet,\r\n
    consectetur adipiscing elit, sed do\r\n
    eiusmod tempor incididunt ut labore.",
  "Type": "Hidden",
  "Value": "Lorem ipsum dolor sit amet,\r\n
    consectetur adipiscing elit, sed do\r\n
    eiusmod tempor incididunt ut labore."
}
```
Это ломает спецификацию JSON. 
В любом случае, можно этим просто не пользоваться, для совместимости с другими программами.

## Минусы
- Настройка производится вручную редактированием JSON файла, что требует некоторой сноровки.
- Баг(и) ниже.

## Известные баги
- При первом автозапуске (если он включен) потребуется вновь выбрать файл. 

## TODO:
- Сделать дополнительное приложение по упрощенному созданию JSON файла.

## Changelog
###### v1.1.1
- Изменена иконка на контрастную
###### v1.1 
- Исправлен принцип работы с данными. Теперь данные после импорта хранятся в зашифрованном виде в UserSpace-настройках приложения. 
Более не требуется постоянно хранить файл с данными в открытом виде для работы программы. 
- В связи с пунктом выше, добавлена возможность выгрузки из настроек файла в расшифрованном виде, чтобы быстро внести корректировки.
- Добавлено окно "О программе".
- Поправлены мелкие баги.

