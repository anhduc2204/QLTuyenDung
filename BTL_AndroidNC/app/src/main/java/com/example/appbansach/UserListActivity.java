package com.example.appbansach;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.annotation.SuppressLint;
import android.content.Intent;
import android.os.Bundle;
import android.view.MenuItem;
import android.widget.Toast;
import androidx.appcompat.widget.Toolbar;

import com.example.appbansach.Adapter.UserAdapter;
import com.example.appbansach.modle.User;
import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.ValueEventListener;
import java.util.ArrayList;
import java.util.List;

public class UserListActivity extends AppCompatActivity {
    private RecyclerView userRecyclerView;
    private DatabaseReference databaseReference;
    private List<User> userList;
    private UserAdapter userAdapter;
    private Toolbar toolbarUserList;

    @SuppressLint("MissingInflatedId")
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_user_list);

        userRecyclerView = findViewById(R.id.user_recycler_view);
        toolbarUserList = findViewById(R.id.toolbarUser);
        setSupportActionBar(toolbarUserList);
        getSupportActionBar().setDisplayHomeAsUpEnabled(true); // Hiển thị nút back
        getSupportActionBar().setTitle("Danh sách");

        userRecyclerView.setLayoutManager(new LinearLayoutManager(this));
        userList = new ArrayList<>();
        userAdapter = new UserAdapter(userList);
        userRecyclerView.setAdapter(userAdapter);

        // Khởi tạo Firebase Database reference
        databaseReference = FirebaseDatabase.getInstance().getReference().child("accounts");

        // Lấy dữ liệu người dùng từ Firebase
        getUsersFromDatabase();
    }

    private void getUsersFromDatabase() {
        databaseReference.addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                userList.clear();
                for (DataSnapshot snapshot : dataSnapshot.getChildren()) {
                    User user = snapshot.getValue(User.class);
                    if (user != null && "user".equals(snapshot.child("role").getValue(String.class))) {
                        userList.add(user);
                    }
                }
                userAdapter.notifyDataSetChanged();
            }

            @Override
            public void onCancelled(@NonNull DatabaseError databaseError) {
                Toast.makeText(UserListActivity.this, "Đã có lỗi xảy ra, vui lòng thử lại", Toast.LENGTH_SHORT).show();
            }
        });
    }

    @Override
    public boolean onOptionsItemSelected(@NonNull MenuItem item) {
        if (item.getItemId() == android.R.id.home) {
            Intent intent = new Intent(UserListActivity.this, MainActivityAdmin.class);
            startActivity(intent);
            finish(); // Để kết thúc UserListActivity
            return true;
        }
        return super.onOptionsItemSelected(item);
    }
}
