package ru.gorbunov.dto;

import lombok.Data;
import lombok.NoArgsConstructor;

import java.time.LocalDate;

@Data
@NoArgsConstructor
public class OwnerDto {
    private String name;
    private LocalDate birthDate;

    public OwnerDto(String name, LocalDate birthDate) {
        this.name = name;
        this.birthDate = birthDate;
    }
}
