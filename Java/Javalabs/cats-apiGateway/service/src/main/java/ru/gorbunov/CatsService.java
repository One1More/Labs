package ru.gorbunov;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;
import ru.gorbunov.dto.Breeds;
import ru.gorbunov.dto.CatDto;
import ru.gorbunov.dto.CatReturnDto;
import ru.gorbunov.dto.Colors;

import java.util.List;

@Component
public class CatsService {
    private final CatsClient client;
    private final KafkaProducer producer;

    @Autowired
    public CatsService(CatsClientImpl client, KafkaProducer producer) {
        this.client = client;
        this.producer = producer;
    }

    public void addCat(CatDto catDto) {
        producer.sendMessage("add-cat", catDto);
    }

    public void deleteCat(long id) {
        producer.sendMessage("delete-cat", id);

    }

    public void setCatOwner(long catId, long id) {
        producer.sendMessage("set-cat-owner", new CatAndOwnerDto(catId, id));
    }

    public void addCatFriend(long id, long friendId) {
        producer.sendMessage("add-cat-friend", new TwoCatsDto(id, friendId));
    }

    public List<CatReturnDto> findByParams(Colors color, Breeds breed) {
        return client.getCats(color, breed);
    }
}
