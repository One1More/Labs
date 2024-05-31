package ru.gorbunov;

import ru.gorbunov.dto.Breeds;
import ru.gorbunov.dto.CatReturnDto;
import ru.gorbunov.dto.Colors;

import java.util.List;

public interface CatsClient {
    List<CatReturnDto> getCats(Colors color, Breeds breed);
}
