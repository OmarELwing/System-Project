import 'package:flutter/material.dart';
import 'models.dart';

class SubjectDetailsScreen extends StatelessWidget {
  final SubjectModel? subject;

  const SubjectDetailsScreen({super.key, this.subject});

  @override
  Widget build(BuildContext context) {
    final title = subject?.title ?? "Database Systems";
    final code = subject?.code ?? "CS301";
    final creditHours = subject?.creditHours ?? 3;
    final doctor = subject?.doctorName ?? "Dr.Ahmed Al-Abbasi";
    final schedule = subject?.schedule ?? "Sun . 10:00 AM";
    final room = subject?.room ?? "Room 302";
    final description = subject?.description ?? "Database Systems and relational database concepts.";

    return Scaffold(
      appBar: AppBar(
        leading: IconButton(
          icon: const Icon(Icons.arrow_back, color: Color(0xFF1E4630)),
          onPressed: () => Navigator.maybePop(context),
        ),
        title: const Text('My Subjects', style: TextStyle(color: Color(0xFF1E4630), fontWeight: FontWeight.bold)),
        backgroundColor: Colors.transparent,
        elevation: 0,
      ),
      body: SingleChildScrollView(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          children: [
            Container(
              padding: const EdgeInsets.all(16),
              decoration: BoxDecoration(color: Colors.white, borderRadius: BorderRadius.circular(16)),
              child: Row(
                children: [
                  const CircleAvatar(backgroundColor: Color(0xFFE8F5E9), child: Icon(Icons.menu_book, color: Color(0xFF1E4630))),
                  const SizedBox(width: 12),
                  Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      Text(title, style: const TextStyle(fontWeight: FontWeight.bold, fontSize: 16)),
                      Text('$code | $creditHours Credit Hours', style: const TextStyle(color: Colors.grey, fontSize: 12)),
                    ],
                  )
                ],
              ),
            ),
            const SizedBox(height: 16),
            Container(
              width: double.infinity,
              padding: const EdgeInsets.all(16),
              decoration: BoxDecoration(color: Colors.white, borderRadius: BorderRadius.circular(16)),
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  const Text('Description', style: TextStyle(fontWeight: FontWeight.bold)),
                  const SizedBox(height: 8),
                  Text(description, style: const TextStyle(color: Colors.grey)),
                ],
              ),
            ),
            const SizedBox(height: 16),
            Container(
              padding: const EdgeInsets.all(16),
              decoration: BoxDecoration(color: Colors.white, borderRadius: BorderRadius.circular(16)),
              child: Column(
                children: [
                  ListTile(leading: const Icon(Icons.person, color: Color(0xFF1E4630)), title: const Text('Doctor'), subtitle: Text(doctor)),
                  ListTile(leading: const Icon(Icons.calendar_today, color: Color(0xFF1E4630)), title: const Text('Schedule'), subtitle: Text(schedule)),
                  ListTile(leading: const Icon(Icons.location_on, color: Color(0xFF1E4630)), title: const Text('Classroom'), subtitle: Text(room)),
                ],
              ),
            )
          ],
        ),
      ),
    );
  }
}