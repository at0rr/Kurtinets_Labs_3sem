# test_main.py
import pytest
from pytest_unordered import unordered

from main import (
    HardDrive, Computer, HardDriveComputer,
    first_query, second_query, third_query
)

@pytest.fixture
def test_one_to_many_data():
    computers = [
        Computer(1, "Компьютер A"),
        Computer(2, "Компьютер B"),
        Computer(3, "Сервер C"),
    ]
    hard_drives = [
        HardDrive(1, "HDD1", 1000, 1),
        HardDrive(2, "HDD2", 500, 1),
        HardDrive(3, "HDD3", 2000, 2),
        HardDrive(4, "HDD4", 750, 3),
        HardDrive(5, "HDD5", 1000, 2),
    ]
    return computers, hard_drives

@pytest.fixture
def test_many_to_many_data():
    computers = [
        Computer(1, "Компьютер A"),
        Computer(2, "Компьютер B"),
        Computer(3, "Сервер C"),
        Computer(4, "Компьютер D"),
    ]
    hard_drives = [
        HardDrive(1, "HDD1", 1000, -1),
        HardDrive(2, "HDD2", 500, -1),
        HardDrive(3, "HDD3", 2000, -1),
        HardDrive(4, "HDD4", 750, -1),
        HardDrive(5, "HDD5", 1000, -1),
    ]
    relations = [
        HardDriveComputer(1, 1),
        HardDriveComputer(1, 2),
        HardDriveComputer(2, 1),
        HardDriveComputer(3, 2),
        HardDriveComputer(4, 3),
        HardDriveComputer(5, 2),
        HardDriveComputer(5, 4),
        HardDriveComputer(3, 4),
        HardDriveComputer(2, 3),
    ]
    return computers, hard_drives, relations

def test_first_query(test_one_to_many_data):
    computers, hard_drives = test_one_to_many_data
    expected = [
        ("Компьютер A", "HDD1"),
        ("Компьютер A", "HDD2"),
        ("Компьютер B", "HDD3"),
        ("Компьютер B", "HDD5"),
        ("Сервер C", "HDD4"),
    ]
    result = first_query(computers, hard_drives)
    assert result == expected

def test_second_query(test_one_to_many_data):
    computers, hard_drives = test_one_to_many_data
    expected = [
        ("Компьютер B", 3000),
        ("Компьютер A", 1500),
        ("Сервер C", 750),
    ]
    result = second_query(computers, hard_drives)
    assert result == expected

def test_third_query(test_many_to_many_data):
    computers, hard_drives, relations = test_many_to_many_data
    expected = unordered([
        ("Компьютер A", "HDD1", 1000),
        ("Компьютер A", "HDD2", 500),
        ("Компьютер B", "HDD1", 1000),
        ("Компьютер B", "HDD3", 2000),
        ("Компьютер B", "HDD5", 1000),
        ("Компьютер D", "HDD3", 2000),
        ("Компьютер D", "HDD5", 1000),
    ])
    result = third_query(computers, hard_drives, relations,
                         lambda name: "компьютер" in name)
    assert result == expected
