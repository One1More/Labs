package ru.gorbunov.models;

import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;

@Data
@Entity
@Table(name="Cats")
@NoArgsConstructor
@AllArgsConstructor
public class Cat {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private long id;
    private String name;
    private LocalDate birthDate;
    private Breeds breed;
    private Colors color;
    @ManyToOne
    private Owner owner;
    @ManyToMany
    private List<Cat> catsFriends;

    public Cat(String name, LocalDate birthDate, Breeds breed, Colors color) {
        this.name = name;
        this.birthDate = birthDate;
        this.breed = breed;
        this.color = color;
        catsFriends = new ArrayList<>();
    }
}
