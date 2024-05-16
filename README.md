# Vending Machine Console Application

## Описание

Это консольное приложение для работы с вендинговым автоматом. Приложение позволяет пользователю взаимодействовать с вендинговым автоматом через команды, такие как добавление денег, покупка товаров, получение сдачи и отображение доступных товаров.

## Функциональные возможности

- **AddMoney [amount]**: Добавляет указанную сумму к текущему балансу.
- **BuyGood [item_id] [quantity]**: Покупает указанное количество товара по ID.
- **GetChange**: Возвращает сдачу и обнуляет баланс.
- **ShowCommands**: Показывает список доступных команд.
- **ShowGoods**: Показывает список доступных товаров.
- **Login**: Вход в систему как администратор (для будущего расширения функциональности).

## Структура проекта

VendingMachine
├── Commands
│ ├── AddMoney.cs
│ ├── BuyGood.cs
│ ├── GetChange.cs
│ ├── Login.cs
│ ├── ShowCommands.cs
│ └── ShowGoods.cs
├── Interfaces
│ ├── ICommand.cs
│ ├── ICommandInput.cs
│ └── IOrder.cs
├── Models
│ ├── Good.cs
│ ├── Order.cs
│ ├── FreeOrder.cs
│ └── VendingMachine.cs
├── Router
│ ├── Router.cs
│ ├── RouterState.cs
│ ├── DefaultState.cs
│ └── AdminState.cs
├── Utilities
│ ├── ConsoleCommandInput.cs
│ └── ConsoleOutput.cs
├── Program.cs
├── Request.cs
└── VendingMachine.sln

## Как использовать
После запуска приложения в консоли, вы увидите приветственное сообщение и приглашение ввести команду.

#Добавить деньги
Чтобы добавить деньги к текущему балансу, используйте команду AddMoney и укажите сумму:

Enter a command: AddMoney 50
Added 50 to the balance. Current balance: 150

Показать доступные команды
Чтобы увидеть список всех доступных команд, используйте команду ShowCommands:

Enter a command: ShowCommands
Available commands:
AddMoney
GetChange
BuyGood
ShowCommands
ShowGoods

Показать доступные товары
Чтобы увидеть список всех товаров, доступных для покупки, используйте команду ShowGoods:

Enter a command: ShowGoods
Available goods:
0: Coke, Price: 25, Available: 10
1: Pepsi, Price: 35, Available: 8
2: Water, Price: 10, Available: 20

Купить товар
Чтобы купить товар, используйте команду BuyGood, указывая ID товара и количество:

Enter a command: BuyGood 0 2
Purchased 50 worth of goods.
Purchased item: Coke, Quantity: 2

Получить сдачу
Чтобы получить сдачу и обнулить баланс, используйте команду GetChange:

Enter a command: GetChange
Returned 100 as change. Current balance: 0

