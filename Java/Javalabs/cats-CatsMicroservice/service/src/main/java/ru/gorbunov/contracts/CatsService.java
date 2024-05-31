package ru.gorbunov.contracts;

import ru.gorbunov.dto.Breeds;
import ru.gorbunov.dto.CatDto;
import ru.gorbunov.dto.CatReturnDto;
import ru.gorbunov.dto.Colors;


import java.util.List;

public interface CatsService {
    List<CatReturnDto> getAllCats();
    CatReturnDto addCat(CatDto cat);
    void deleteCat(long id);
    void setCatOwner(long catId, long id);
    void addCatFriend(long id, long friendId);
    List<CatReturnDto> findByColor(Colors color);
    List<CatReturnDto> findByBreed(Breeds breed);
    List<CatReturnDto> findByParams(Colors color, Breeds breed);
}
