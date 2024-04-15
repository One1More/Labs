package ru.gorbunov.dto;

import lombok.Data;
import lombok.NoArgsConstructor;
import ru.gorbunov.models.Breeds;
import ru.gorbunov.models.Colors;

import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;

@Data
@NoArgsConstructor
public class CatDto {
    private String name;
    private LocalDate birthDate;
    private Breeds breed;
    private Colors color;
    private OwnerDto owner;
    private List<CatDto> catsFriends;

    public CatDto(String name, LocalDate birthDate, Breeds breed, Colors color) {
        this.name = name;
        this.birthDate = birthDate;
        this.breed = breed;
        this.color = color;
        catsFriends = new ArrayList<>();
    }
}
