# main.py
from typing import List, Any, Callable, Dict
from dataclasses import dataclass
from collections import defaultdict

@dataclass
class HardDrive:
    hdd_id: int
    model: str
    capacity: int
    computer_id: int

@dataclass
class Computer:
    comp_id: int
    name: str

@dataclass
class HardDriveComputer:
    hard_drive_id: int
    computer_id: int

def get_computers() -> List[Computer]:
    """ Функция для получения данных компьютеров. """
    return [
        Computer(1, "Компьютер Dell XPS"),
        Computer(2, "Компьютер HP Pavilion"),
        Computer(3, "Сервер Lenovo"),
        Computer(4, "Компьютер Apple MacBook")
    ]

def get_hard_drives() -> List[HardDrive]:
    """ Функция для получения данных жёстких дисков. """
    return [
        HardDrive(1, "Seagate 1TB", 1000, 1),
        HardDrive(2, "WD 500GB", 500, 1),
        HardDrive(3, "Samsung 2TB", 2000, 2),
        HardDrive(4, "Crucial 1TB SSD", 1000, 3),
        HardDrive(5, "Toshiba 750GB", 750, 2)
    ]

def get_hard_drive_computers() -> List[HardDriveComputer]:
    """ Функция для получения связей многие ко многим. """
    return [
        HardDriveComputer(1, 1),
        HardDriveComputer(1, 4),
        HardDriveComputer(2, 1),
        HardDriveComputer(3, 2),
        HardDriveComputer(4, 3),
        HardDriveComputer(5, 2),
        HardDriveComputer(5, 4)
    ]

def print_data(data: List[Any], headers: List[str], title: str, column_width: int = 30) -> None:
    """
    Функция для вывода данных в виде таблицы.
    Принимает данные, заголовки столбцов и заголовок таблицы.
    """
    total_length = len(headers) * column_width
    columns = len(headers)

    print(f"{title:=^{total_length}}")
    print(("{:<{column_width}}" * columns).format(*headers, column_width=column_width))
    print()
    print("\n".join(
        ("{:<{column_width}}" * columns).format(*i, column_width=column_width) for i in data
    ))
    print()

def first_query(computers: List[Computer], hard_drives: List[HardDrive]) -> List[Any]:
    """ Реализация первого запроса: Связанные объекты (один-ко-многим). """
    computer_dict = {c.comp_id: c for c in computers}

    joined = [(computer_dict[hd.computer_id].name, hd.model)
              for hd in hard_drives
              if hd.computer_id in computer_dict]

    return sorted(joined, key=lambda x: x[0])

def second_query(computers: List[Computer], hard_drives: List[HardDrive]) -> List[Any]:
    """ Реализация второго запроса: Суммарная ёмкость (один-ко-многим). """
    computer_dict = {c.comp_id: c for c in computers}

    capacity_sum = defaultdict(int)
    for hd in hard_drives:
        capacity_sum[hd.computer_id] += hd.capacity

    comp_capacities = [(computer_dict[cid].name, total)
                       for cid, total in capacity_sum.items()
                       if cid in computer_dict]

    return sorted(comp_capacities, key=lambda x: x[1], reverse=True)

def third_query(computers: List[Computer], hard_drives: List[HardDrive],
                relations: List[HardDriveComputer], condition: Callable) -> List[Any]:
    """ Реализация третьего запроса: Фильтрация по условию (многие-ко-многим). """
    filtered_computers = [c for c in computers
                          if condition(c.name.lower())]

    hard_drive_dict = {hd.hdd_id: hd for hd in hard_drives}

    comp_hds = defaultdict(list)
    for link in relations:
        hd = hard_drive_dict.get(link.hard_drive_id)
        if hd:
            comp_hds[link.computer_id].append(hd)

    result = []
    for comp in filtered_computers:
        for hd in comp_hds.get(comp.comp_id, []):
            result.append((comp.name, hd.model, hd.capacity))

    return result

def main() -> None:
    computers = get_computers()
    hard_drives = get_hard_drives()
    relations = get_hard_drive_computers()

    # Первый запрос
    print_data(first_query(computers, hard_drives),
               ["Компьютер", "Жёсткий диск"], "Запрос 1")

    # Второй запрос
    print_data(second_query(computers, hard_drives),
               ["Компьютер", "Суммарная ёмкость (ГБ)"], "Запрос 2")

    # Третий запрос
    print_data(third_query(computers, hard_drives, relations,
                           lambda name: "компьютер" in name),
               ["Компьютер", "Жёсткий диск", "Ёмкость (ГБ)"], "Запрос 3")

if __name__ == "__main__":
    main()
