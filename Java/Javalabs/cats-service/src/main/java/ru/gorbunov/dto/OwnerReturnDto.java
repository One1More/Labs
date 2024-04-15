package ru.gorbunov.dto;

import lombok.Data;
import lombok.NoArgsConstructor;

import java.time.LocalDate;

@Data
@NoArgsConstructor
public class OwnerReturnDto {
    private long id;
    private String name;
    private LocalDate birthDate;

    public OwnerReturnDto(long id, String name, LocalDate birthDate) {
        this.id = id;
        this.name = name;
        this.birthDate = birthDate;
    }
}

