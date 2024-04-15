package ru.gorbunov.contracts;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import ru.gorbunov.models.Owner;

@Repository
public interface OwnersRepository extends JpaRepository<Owner, Long> {
}
