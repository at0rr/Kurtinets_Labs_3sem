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

computers = [
    Computer(1, "Компьютер Dell XPS"),
    Computer(2, "Компьютер HP Pavilion"),
    Computer(3, "Сервер Lenovo"),
    Computer(4, "Компьютер Apple MacBook")
]

hard_drives = [
    HardDrive(1, "Seagate 1TB", 1000, 1),
    HardDrive(2, "WD 500GB", 500, 1),
    HardDrive(3, "Samsung 2TB", 2000, 2),
    HardDrive(4, "Crucial 1TB SSD", 1000, 3),
    HardDrive(5, "Toshiba 750GB", 750, 2)
]

hard_drive_computers = [
    HardDriveComputer(1, 1),
    HardDriveComputer(1, 4),
    HardDriveComputer(2, 1),
    HardDriveComputer(3, 2),
    HardDriveComputer(4, 3),
    HardDriveComputer(5, 2),
    HardDriveComputer(5, 4)
]
print("ЗАПРОС 1: Связанные объекты (один-ко-многим)\n")

computer_dict = {c.comp_id: c for c in computers}

joined = [
    (computer_dict[hd.computer_id].name, hd.model)
    for hd in hard_drives
    if hd.computer_id in computer_dict
]

joined_sorted = sorted(joined, key=lambda x: x[0])

for comp_name, hd_model in joined_sorted:
    print(f"Компьютер: {comp_name:30} | Жёсткий диск: {hd_model}")

print(f"\nВсего связей: {len(joined_sorted)}")

print("\nЗАПРОС 2: Суммарная ёмкость (один-ко-многим)\n")

capacity_sum = defaultdict(int)
for hd in hard_drives:
    capacity_sum[hd.computer_id] += hd.capacity

comp_capacities = [
    (computer_dict[cid].name, total)
    for cid, total in capacity_sum.items()
    if cid in computer_dict
]

comp_capacities_sorted = sorted(comp_capacities, key=lambda x: x[1], reverse=True)

for comp_name, total_capacity in comp_capacities_sorted:
    print(f"Компьютер: {comp_name:30} | Суммарная ёмкость: {total_capacity:5} ГБ")
print("\nЗАПРОС 3: Фильтрация по условию (многие-ко-многим)")

filtered_computers = [
    c for c in computers
    if "компьютер" in c.name.lower()
]

hard_drive_dict = {hd.hdd_id: hd for hd in hard_drives}

comp_hds = defaultdict(list)
for link in hard_drive_computers:
    comp_hds[link.computer_id].append(hard_drive_dict.get(link.hard_drive_id))

for comp in filtered_computers:
    print(f"\nКомпьютер: {comp.name}")
    hds = comp_hds.get(comp.comp_id, [])
    for hd in filter(None, hds):
        print(f"\tЖёсткий диск: {hd.model} ({hd.capacity} ГБ)")

print(f"\nВсего отфильтрованных компьютеров: {len(filtered_computers)}")
