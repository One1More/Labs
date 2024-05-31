package ru.gorbunov.contrats;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;
import ru.gorbunov.dto.Breeds;
import ru.gorbunov.dto.Colors;
import ru.gorbunov.models.Cat;

import java.util.List;

@Repository
public interface CatsRepository extends JpaRepository<Cat, Long> {
    List<Cat> findByColor(Colors color);
    List<Cat> findByBreed(Breeds breed);
    @Query("SELECT c FROM Cat c WHERE (c.color = :colorParam) AND (c.breed = :breedParam)")
    List<Cat> findByParams(@Param("colorParam") Colors color, @Param("breedParam") Breeds breed);
}
