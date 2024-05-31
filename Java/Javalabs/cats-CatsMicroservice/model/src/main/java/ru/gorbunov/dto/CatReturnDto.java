package ru.gorbunov.dto;

import lombok.Data;
import lombok.NoArgsConstructor;

import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;

@Data
@NoArgsConstructor
public class CatReturnDto {private long id;
    private String name;
    private LocalDate birthDate;
    private Breeds breed;
    private Colors color;
    private long owner;
    private List<CatDto> catsFriends;

    public CatReturnDto(long id, String name, LocalDate birthDate, Breeds breed, Colors color) {
        this.id = id;
        this.name = name;
        this.birthDate = birthDate;
        this.breed = breed;
        this.color = color;
        catsFriends = new ArrayList<>();
    }
}
